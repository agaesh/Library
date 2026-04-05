<template>
    <div class="base-card bg-white">
        <!-- Body -->
        <div class="base-card-body">
            <slot name="card-body" />
        </div>

        <!-- Footer (optional) -->
        <div v-if="$slots.footer" class="base-card-footer">
            <slot name="footer" />
        </div>
    </div>
</template>

<script setup>
    // purely presentational
</script>
<style scoped>
    /* ===== Base Card Container ===== */
    .base-card {
        display: flex;
        flex-direction: column;
        background-color: #ffffff; /* bg-white */
        border-radius: 12px;
        border: 1px solid #e2e8f0; /* subtle border */
        box-shadow: 0 2px 6px rgba(0, 0, 0, 0.04);
        overflow: hidden;
        transition: all 0.2s ease;
        max-height:360px;
        margin-bottom:10px;
    }

    /* Optional hover effect */
    .base-card:hover {
        transform: translateY(-2px);
        box-shadow: 0 6px 14px rgba(0, 0, 0, 0.08);
    }

    /* ===== Card Body ===== */
    .base-card-body {
        padding: 10px;
        flex: 1;
    }

    /* ===== Card Footer ===== */
    .base-card-footer {
        padding: 12px 16px;
        border-top: 1px solid #e2e8f0;
        background-color: #f8fafc;
        display: flex;
        align-items: center;
        justify-content: flex-end;
        gap: 8px;
    }
</style>