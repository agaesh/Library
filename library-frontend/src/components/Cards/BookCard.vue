<script setup>
    import BaseCard from './BaseCard.vue'

    defineProps({
        book:{
            type: Object,
            required: true
        }
    })

    defineEmits(['edit', 'delete'])
</script>

<template>
    <BaseCard class="base-card--hover">
        <!-- Body slot -->
        <template #card-body>
            <div class="card-body">
                <div class="w-20 h-28 rounded-xl bg-slate-100 overflow-hidden relative">
                    <img :src="book.cover" alt="Book cover" class="w-full h-full " />
                </div>

                <div class="content mx-md">
                    <div class="w-full flex flex-center justify-between gap-2">
                        <span class="category font-black text-blue-600 uppercase tracking-widest bg-blue-50 px-sm py-0.5 rounded-md">{{ book.genre }}</span>

                        <div class="flex items-center gap-1">
                            <div :class="book.status === 'active' ? 'bg-emerald-400' : 'bg-slate-300' " class="w-1.5 h-1.5 rounded-full"></div>
                            <span class="book-status font-bold text-slate-500 uppercase">{{ book.status }}</span>
                        </div>
                    </div>

                    <h3 class="title">{{ book.name }}</h3>
                    <p class="author text-slate-500 font-bold-600">{{ book.author }}</p>
                    <p class="isbn font-mono my-L  flex items-center gap-2">
                        <i class="fas fa-barcode"></i>
                        {{ book.isbn }}
                    </p>
                    <a class="view-detail-cta mb-0 text-sm text-blue-500 tracking-widest font-bold">
                        View Detail
                        <i class="fa-solid fa-chevron-right ml-2 text-xs"></i>
                    </a>
                </div>
            </div>
        </template>

        <!-- Footer -->
        <template #footer>
            <div class="w-full border-slat e-100 flex items-center justify-between">
                <span class="text-xs font-semibold text-slate-400 tracking-tighter">
                    ADDED {{ book.createdAt }}
                </span>

                <div class="flex items-center gap-1">
                    <button class="bg-slate-100 w-10 h-10 flex items-center justify-center rounded-lg hover:bg-white hover:text-blue-600 transition-all text-slate-400">
                        <i class="far fa-edit fa-lg"></i>
                    </button>
                    <button class="bg-slate-100 w-10 h-10 flex items-center justify-center rounded-lg hover:bg-white hover:text-rose-500 transition-all text-slate-400">
                        <i class="far fa-trash-alt fa-lg"></i>
                    </button>
                    <button class="bg-slate-100 w-10 h-10 flex items-center justify-center rounded-lg hover:bg-white hover:text-indigo-500 transition-all text-slate-400">
                        <i class="fas fa-link fa-lg"></i>
                    </button>
                    <div class="w-px h-4 bg-slate-200 mx-1"></div>
                    <button class="w-10 h-10 flex items-center justify-center rounded-lg bg-white border border-slate-200 text-slate-600 hover:border-blue-200 transition-all">
                        <i class="fas fa-ellipsis-h fa-lg"></i>
                    </button>
                </div>
            </div>

        </template>
    </BaseCard>
</template>


<style scoped>
    /* ===== Layout ===== */

    * {
        box-sizing: border-box;
    }

    .card-body .content > * {
        /* removes default spacing */
        padding: 0; /* just in case content has padding */
    }

    .card-body {
        display: flex;
        padding: 10px;
    }

    .row {
        display: flex;
        gap: 16px;
    }

    .category {
        font-size: 10px;
        font-weight: 700;
    }

    .book-status {
        font-size: 10px;
    }

    /* ===== Image ===== */
    .cover {
        width: 80px;
        height: 112px;
        border-radius: 12px;
        object-fit: cover;
        flex-shrink: 0;
    }

    /* ===== Content ===== */
    .content {
        flex: 1;
        min-width: 0;
        display: flex;
        align-items: flex-start;
        flex-direction: column;
        justify-content: center;
    }

    /* ===== Title ===== */
    .title {
        font-weight: 700;
        color: #0f172a;
        line-height: 1.3;
        /* line clamp */
        display: -webkit-box;
        -webkit-line-clamp: 2;
        -webkit-box-orient: vertical;
        overflow: hidden;
        margin: 5px 0px;
        font-size: 16px;
    }

    /* ===== Author ===== */
    .author {
        font-size: 15px;
        color: #64748b;
        margin: 0px;
    }

    .isbn {
        font-size: 13px;
        color: dimgray;
    }

    .view-detail-cta {
        margin-left: auto;
    }
    /* ===== Footer ===== */
    .footer-text {
        font-size: 12px;
        font-weight: 600;
        color: #94a3b8;
    }
</style>